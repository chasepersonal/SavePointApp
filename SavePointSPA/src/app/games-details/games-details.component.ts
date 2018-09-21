import { GamesService } from './../_services/games.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-games-details',
  templateUrl: './games-details.component.html',
  styleUrls: ['./games-details.component.css']
})
export class GamesDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute, private data: GamesService) { }

  id: any;
  game: any = {};

  ngOnInit() {
    this.getSingleGame();
  }

  getSingleGame(): any {

    /* Use paramMap to find the id parameter from the url */
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
    });

    /* Use the current idto pull data from the appropriate service */
    this.data.getGame(this.id).subscribe(data =>  {
      this.game = data;
    });
  }
}
