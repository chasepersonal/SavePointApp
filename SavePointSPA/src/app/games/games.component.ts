import { Component, OnInit } from '@angular/core';
import { GamesService } from '../_services/games.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {

  constructor(private data: GamesService) { }

  games$: Object;

  ngOnInit() {
    this.loadGames();
  }

  loadGames() {
    this.data.getGames().subscribe(data => {
      this.games$ = data;
    });

}
