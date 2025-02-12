import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButton } from '@angular/material/button';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { LocalStorageService } from '../localstorage.service';

@Component({
  selector: 'app-select-dates',
  imports: [
    ReactiveFormsModule,
      MatFormFieldModule,
      MatDatepickerModule,
      MatButton,
      MatAutocompleteModule,
      MatInputModule,
      MatStepperModule
  ],
  templateUrl: './select-dates.component.html',
  styleUrl: './select-dates.component.css'
})
export class SelectDatesComponent implements OnInit {
  private localStorageService = inject(LocalStorageService);

  public dateForm = new FormGroup({
    from: new FormControl<Date | null>(this.localStorageService.loadedBookingData()?.from, {
      validators: [ Validators.required ]
    }),
    to: new FormControl<Date | null>(this.localStorageService.loadedBookingData()?.to, {
      validators: [ Validators.required ]
    })
  });

  ngOnInit(): void {
    this.localStorageService.Load();

    const loadedData = this.localStorageService.loadedBookingData();

    if (loadedData) {
      this.dateForm.patchValue({
        from: loadedData?.from,
        to: loadedData?.to
      })
    }
  }

  onSubmit() {
    if (this.dateForm.invalid) {
      console.log('INVALID FORM');
      return;
    }

    const enteredFromDate = this.dateForm.value.from;
    const enteredToDate = this.dateForm.value.to;

    if (enteredFromDate && enteredToDate) {
      this.localStorageService.SaveDatesData(enteredFromDate, enteredToDate);
    }
  }

  reset() {
    this.localStorageService.Reset();
    this.dateForm.reset();
  }
}
