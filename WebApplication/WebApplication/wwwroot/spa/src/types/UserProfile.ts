import FilmDTO from "./films";

export interface UserProfile {
    Name: string;

    City: string;

    FilmOnActive: FilmDTO;

    WatchedFilms: FilmDTO;
}

export default UserProfile;