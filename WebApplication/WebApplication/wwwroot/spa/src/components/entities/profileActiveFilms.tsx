import { useState, useEffect } from "react";
import { Alert, Spinner, Col } from "react-bootstrap";
import { fetchActiveFilmsOfUser } from "../../services/filmService";
import FilmDTO from "../../types/films";
import ActiveFilm from "./activeFilmforUser";

const ProfileActiveFilms = () => {
    const [activeFilms, setActiveFilms] = useState<FilmDTO[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        fetchActiveFilmsOfUser().then((activeFilms) => {
            setActiveFilms(activeFilms);
            setError("")
        })
            .catch((e: Error) => setError(e.message));
    }, []);

    return (
        <>
            <div>
                {error && <Alert variant='danger'>Falled to fetch</Alert>}
                {!error && activeFilms.length === 0 && <Spinner animation="border" variant="primary" />}
                <Col>
                    {activeFilms.length > 0 && activeFilms.map((film) =>
                        <ActiveFilm posterUrlPreview={film.posterUrlPreview}
                            webUrl={film.webUrl} nameRu={film.nameRu}
                            filmIdApi={film.filmIdApi} description={film.description}
                            kinopoiskRating={film.kinopoiskRating} nameEn={film.nameEn} year={film.year} />)}
                </Col>
            </div>


        </>
    );
}

export default ProfileActiveFilms;