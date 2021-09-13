import { FilmDTO } from "../types/films"
import { httpGet, httpPost } from "./requestApi"


export const fetchRecomendedFilm = () => {
    return httpPost<FilmDTO[]>("recomendedFilm");
}