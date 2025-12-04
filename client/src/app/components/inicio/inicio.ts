import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-inicio',
  imports: [MatCardModule, MatListModule, MatIconModule],
  templateUrl: './inicio.html',
})
export class Inicio {}
