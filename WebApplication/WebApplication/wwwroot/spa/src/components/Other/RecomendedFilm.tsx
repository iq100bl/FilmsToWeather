import { MDBCard, MDBRow, MDBCol, MDBCardImage, MDBCardBody, MDBCardTitle, MDBCardText } from "mdb-react-ui-kit";
import { useState, useEffect } from "react";
import { Alert, Spinner, Col } from "react-bootstrap";
import { fetchRecomendedFilm } from "../../services/recomendedFilmsService";
import FilmDTO from "../../types/films";
import Film from "../general/film";




const RecomendedFilm = () => {

    const [recFilm, setRecFilm] = useState<FilmDTO>();
    const [error, setError] = useState("");

    useEffect(() => {
        fetchRecomendedFilm().then((recFilm) => {
            setRecFilm(recFilm);
            setError("")
        })
            .catch((e: Error) => setError(e.message));
    }, []);

    return (
        <>
            <div className="row row-cols-1 row-cols-sm-2 row-cols-md3 g-3 p-1 m-2">
                {error && <Alert variant='danger'>Falled to fetch</Alert>}
                {!error && recFilm === undefined && <Spinner animation="border" variant="primary" />}
                <Col xs lg="2"></Col>
                <Col>
                    {recFilm && (() =>
                        <Film posterUrlPreview={recFilm.posterUrlPreview} webUrl={recFilm.webUrl} nameRu={recFilm.nameRu} filmId={recFilm.filmId} description={recFilm.description} kinopoiskRating={recFilm.kinopoiskRating} />)}
                </Col>
                <Col></Col>
            </div>

        </>

    );
}

export default RecomendedFilm;