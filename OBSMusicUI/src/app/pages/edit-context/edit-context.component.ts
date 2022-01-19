import { Component, Input, OnInit } from '@angular/core';
import { MusicContext } from 'src/app/obs.music';

@Component({
  selector: 'app-edit-context',
  templateUrl: './edit-context.component.html',
  styleUrls: ['./edit-context.component.scss']
})
export class EditContextComponent implements OnInit {

  @Input() public musicContext?: MusicContext;

  constructor() { }

  ngOnInit(): void {
  }

}
