import { useState, useEffect } from "react";
import { Alert, Spinner, Col } from "react-bootstrap";
import { fetchWatchedFilmsOfUser } from "../../services/filmService";
import FilmDTO from "../../types/films";
import WatchedFilm from "./watchedFilmForUser";


const ProfileWathedFilms = () => {
    const [WatchedFilms, setWatchedFilms] = useState<FilmDTO[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        fetchWatchedFilmsOfUser().then((WatchedFilms) => {
            setWatchedFilms(WatchedFilms);
            setError("")
        })
            .catch((e: Error) => setError(e.message));
    }, []);

    return (
        <>
            <div>
                {error && <Alert variant='danger'>Falled to fetch</Alert>}
                {!error && WatchedFilms.length === 0 && <Spinner animation="border" variant="primary" />}
                {WatchedFilms.length > 0 && WatchedFilms.map((film) =>
                    <WatchedFilm posterUrlPreview={film.posterUrlPreview}
                        webUrl={film.webUrl} nameRu={film.nameRu}
                        filmIdApi={film.filmIdApi} description={film.description}
                        kinopoiskRating={film.kinopoiskRating} nameEn={film.nameEn} year={film.year} />)}
            </div>
        </>
    );
}

export default ProfileWathedFilms;