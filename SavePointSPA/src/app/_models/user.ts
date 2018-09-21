import { Photo } from "./photo";

export interface User {
  id: number;
  username: string;
  favoriteGenres: string;
  favoriteGames: string;
  gender: string;
  created: Date;
  lastActive: Date;
  city: string;
  state: string;
  zipCode: string;
  profilePhotoUrl: string;
  firstName?: string;
  lastName?: string;
  summary?: string;
  profilePhotos?: Photo[];
}
