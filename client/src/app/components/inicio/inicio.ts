import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatDivider, MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { MatDividerModule } from '@angular/material/divider';

@Component({
  selector: 'app-inicio',
  imports: [MatCardModule, MatListModule, MatIconModule, RouterLink, MatDividerModule],
  templateUrl: './inicio.html',
})
export class Inicio {}
