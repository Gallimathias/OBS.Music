import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MusicContext } from 'src/app/obs.music';

@Component({
  selector: 'app-context-dialog',
  templateUrl: './context-dialog.component.html',
  styleUrls: ['./context-dialog.component.scss']
})
export class ContextDialogComponent implements OnInit {

  public contextFormControl: FormControl = new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z0-9_]+$/)]);

  constructor(
    public dialogRef: MatDialogRef<ContextDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: MusicContext) { }

  ngOnInit(): void {
  }

}
