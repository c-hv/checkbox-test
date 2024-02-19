import { Component, OnInit } from '@angular/core';
import { AvailableOperation } from '@app/interfaces/available-operation.interface';
import { CalculationModel } from '@app/interfaces/calculation-model.interface';
import { CalculatorService } from '@app/services/calculator.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {
  operations: AvailableOperation[] = [];
  selectedOperation?: AvailableOperation;
  operandModels: { value: number }[] = [];
  result: number | null = null;
  errorMessage: string | null = null;

  constructor(private calculatorService: CalculatorService) {}

  ngOnInit(): void {
    this.calculatorService.getOperations().subscribe(operations => {
      this.operations = operations;
      this.selectedOperation = this.operations[0]; // Default to the first operation
      this.resetOperands();
    });
  }
  
  onOperationChange(): void {
    this.resetMessages();
    this.resetOperands();
  }
  
  addOperand(): void {
    if (this.selectedOperation && this.operandModels.length < this.selectedOperation.maxOperands) {
      this.operandModels.push({ value: 0 });
    }
  }

  canAddOperand(): boolean {
    return this.selectedOperation ? this.operandModels.length < this.selectedOperation.maxOperands : false;
  }

  resetOperands(): void {
    // Always start with 2 operands by default
    const defaultOperandCount = 2;

    // Use the smaller of maxOperands or defaultOperandCount
    const operandCount = Math.min(this.selectedOperation?.maxOperands ?? defaultOperandCount, defaultOperandCount);
    
    this.operandModels = Array.from({ length: operandCount }, () => ({ value: 0 }));
  }  

  resetMessages(): void {
    this.errorMessage = null;
    this.result = null;
  }

  resetOperandsToZero(): void {
    this.operandModels.forEach(operand => operand.value = 0);
  }

  onCalculate(): void {
    this.resetMessages();
    const calculation: CalculationModel = {
      operands: this.operandModels.map(om => om.value),
      operator: this.selectedOperation?.symbol.toString()!
    };

    this.calculatorService.calculate(calculation).subscribe({
      next: result => {
        this.result = result.result;
      },
      error: error => {
        this.errorMessage = error;
      }
    });
  }
}