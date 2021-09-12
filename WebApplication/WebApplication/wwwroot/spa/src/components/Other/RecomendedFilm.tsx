import { MDBCard, MDBRow, MDBCol, MDBCardImage, MDBCardBody, MDBCardTitle, MDBCardText } from "mdb-react-ui-kit";
import { useState, useEffect } from "react";
import { Alert, Spinner, Col } from "react-bootstrap";
import { fetchRecomendedFilm } from "../../services/recomendedFilmsService";
import FilmDTO from "../../types/films";
import Film from "../general/film";


const RecomendedFilm = () => {

    const [films, setFilms] = useState<FilmDTO[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        fetchRecomendedFilm().then((films) => {
            setFilms(films);
            setError("")
        })
            .catch((e: Error) => setError(e.message));
    }, []);

    return (
        <>
            <div className="row row-cols-1 row-cols-sm-2 row-cols-md3 g-3 p-1 m-2">
                {error && <Alert variant='danger'>Falled to fetch</Alert>}
                {!error && films.length === 0 && <Spinner animation="border" variant="primary" />}
                <Col xs lg="2"></Col>
                <Col>
                    {films.length > 0 && films.map((film) =>
                        <Film posterUrlPreview={film.posterUrlPreview} webUrl={film.webUrl} nameRu={film.nameRu} filmId={film.filmId} description={film.description} kinopoiskRating={film.kinopoiskRating} />)}
                </Col>
                <Col></Col>
            </div>

        </>

    );
}

export default RecomendedFilm;