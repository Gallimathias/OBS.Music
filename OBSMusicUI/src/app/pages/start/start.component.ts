import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { MusicContext } from 'src/app/obs.music';
import { ContextDialogComponent } from '../context-dialog/context-dialog.component';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.scss'],
})
export class StartComponent implements OnDestroy {
  private readonly subscriptions: Subscription;

  constructor(private dialog: MatDialog) {
    this.subscriptions = new Subscription();
  }

  public ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  public openDialog(): void {
    const dialogSub = this.dialog
      .open(ContextDialogComponent, {
        data: { ContextId: '' } as MusicContext,
      })
      .afterClosed()
      .subscribe();

    this.subscriptions.add(dialogSub);
  }
}
