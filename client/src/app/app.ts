import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { ShellComponent } from './components/shell/shell.component';
import { MatIconModule } from '@angular/material/icon';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  imports: [MatButtonModule, MatIconModule, ShellComponent, RouterOutlet],
})
export class App {}
