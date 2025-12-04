import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { ShellComponent } from './components/shell/shell.component';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  imports: [MatButtonModule, MatIconModule, ShellComponent],
})
export class App {}
