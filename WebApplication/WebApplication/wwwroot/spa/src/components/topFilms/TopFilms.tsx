import { useState, useEffect } from "react";
import { Pagination, Alert, Spinner, Col, Nav } from "react-bootstrap";
import { fetchTopFilms } from "../../services/topFilmsService";
import FilmDTO from "../../types/films";
import Film from "../general/film";



const TopFilms = () => {

    let active = 1;
    let items = [];
    for (let number = 1; number <= 13; number++) {
        items.push(
            <Pagination.Item key={number} active={number === active}>
                {number}
            </Pagination.Item>,
        );
    }

    const [films, setFilms] = useState<FilmDTO[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        fetchTopFilms(active).then((films) => {
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
                <Nav>
                    <Pagination size="lg">{items}</Pagination>
                </Nav>
            </div>

        </>

    );
}

export default TopFilms;