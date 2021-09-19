import { useEffect, useState } from "react";
import { Accordion, Alert, Col, Container, Row, Spinner } from "react-bootstrap";
import { fetchActiveFilmsOfUser, fetchWatchedFilmsOfUser } from "../../services/filmsService";
import FilmDTO from "../../types/films";
import ActiveFilm from "../general/activeFilmforUser";
import FastButton from "../general/fastAccesButton"
import WatchedFilm from "../general/watchedFilmForUser";

const Profile = () => {
    const [activeFilms, setActiveFilms] = useState<FilmDTO[]>([]);
    const [WatchedFilms, setWatchedFilms] = useState<FilmDTO[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        fetchActiveFilmsOfUser().then((activeFilms) => {
            setActiveFilms(activeFilms);
            setError("")
        })
            .catch((e: Error) => setError(e.message));
    }, []);

    useEffect(() => {
        fetchWatchedFilmsOfUser().then((WatchedFilms) => {
            setWatchedFilms(WatchedFilms);
            setError("")
        })
            .catch((e: Error) => setError(e.message));
    }, []);
    return (
        <>
            <Container>
                <Accordion defaultActiveKey="0" flush>
                    <Accordion.Item eventKey="0">
                        <Accordion.Header>
                            <div className="row row-cols-1 row-cols-sm-2 row-cols-md3 g-3 p-1 m-2">
                                {error && <Alert variant='danger'>Falled to fetch</Alert>}
                                {!error && activeFilms.length === 0 && <Spinner animation="border" variant="primary" />}
                                <Col xs lg="2"></Col>
                                <Col>
                                    {activeFilms.length > 0 && activeFilms.map((film) =>
                                        <ActiveFilm posterUrlPreview={film.posterUrlPreview} webUrl={film.webUrl} nameRu={film.nameRu} filmId={film.filmId} description={film.description} kinopoiskRating={film.kinopoiskRating} />)}
                                </Col>
                                <Col></Col>
                            </div>
                        </Accordion.Header>
                        <Accordion.Body>

                        </Accordion.Body>
                    </Accordion.Item>
                    <Accordion.Item eventKey="1">
                        <Accordion.Header>
                            <div className="row row-cols-1 row-cols-sm-2 row-cols-md3 g-3 p-1 m-2">
                                {error && <Alert variant='danger'>Falled to fetch</Alert>}
                                {!error && WatchedFilms.length === 0 && <Spinner animation="border" variant="primary" />}
                                <Col xs lg="2"></Col>
                                <Col>
                                    {WatchedFilms.length > 0 && WatchedFilms.map((film) =>
                                        <WatchedFilm posterUrlPreview={film.posterUrlPreview} webUrl={film.webUrl} nameRu={film.nameRu} filmId={film.filmId} description={film.description} kinopoiskRating={film.kinopoiskRating} />)}
                                </Col>
                                <Col></Col>
                            </div>
                        </Accordion.Header>
                        <Accordion.Body>

                        </Accordion.Body>
                    </Accordion.Item>
                </Accordion>
            </Container>
        </>

    );
}

export default Profile;