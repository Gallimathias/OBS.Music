import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditContextComponent } from './pages/edit-context/edit-context.component';
import { StartComponent } from './pages/start/start.component';
import { PlayerComponent } from './player/player.component';

const routes: Routes = [
  {path: "", component: StartComponent},
  {path: "player", component: PlayerComponent},
  {path: "edit/:id", component: EditContextComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
