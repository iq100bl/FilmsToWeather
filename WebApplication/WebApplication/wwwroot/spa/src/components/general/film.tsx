import { MDBCard, MDBRow, MDBCol, MDBCardImage, MDBCardBody, MDBCardTitle, MDBCardText } from "mdb-react-ui-kit";
import React from "react";
import { useState } from "react";
import { Row, Col, Button, DropdownButton, Dropdown, DropdownProps } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { giveChosenFilm, giveRatingFilmFromUser } from "../../services/filmService";
import FilmDTO from "../../types/films";


interface Props extends FilmDTO {

}

const Film = ({ nameRu, kinopoiskRating, posterUrlPreview, webUrl, description, filmIdApi, year, nameEn }: Props) => {
    const [error, setError] = useState("");

    const navigate = useNavigate();

    const film = ({ nameRu, kinopoiskRating, posterUrlPreview, webUrl, description, filmIdApi, year, nameEn });

    const chooseFilm = () => {
        giveChosenFilm(filmIdApi, nameRu, nameEn, year, kinopoiskRating, posterUrlPreview, webUrl, description).then(() => {
            navigate('/spa/profile');
        }).catch((e) => {
            setError(e.message);
        })
    }

    const handleRatingChange = (rate: number) => {
        giveRatingFilmFromUser(filmIdApi, nameRu, nameEn, year, kinopoiskRating, posterUrlPreview, webUrl, description, rate).then(() => {
            navigate('/spa/profile');
        }).catch((e) => {
            setError(e.message);
        })
    }
    return (
        <>
            <MDBCard style={{ maxWidth: '1080px' }}>
                <MDBRow className='g-0'>
                    <MDBCol md='4'>
                        <MDBCardImage src={posterUrlPreview} alt='...' fluid />
                    </MDBCol>
                    <MDBCol md='8'>
                        <MDBCardBody>
                            <MDBCardTitle>{nameRu}</MDBCardTitle>
                            <MDBCardText>
                                {description}
                                <a href={webUrl}> Больше информации на сайте Kinopoisk</a>
                            </MDBCardText>
                            <MDBCardText>
                                <small className='text-muted'>Рейтинг на кинопоиске : {kinopoiskRating}</small>
                                <small className='text-muted'>ID : {filmIdApi}</small>
                            </MDBCardText>
                        </MDBCardBody>
                        <Row>
                            <Col><Button variant="primary" onClick={chooseFilm}>Выбрать</Button></Col>
                            <Col><DropdownButton id="dropdown-basic-button" title="Смотели? Оставьте вашу оценку">
                                <Dropdown.Item onClick={() => handleRatingChange(1)}>1</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(2)}>2</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(3)}>3</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(4)}>4</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(5)}>5</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(6)}>6</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(7)}>7</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(8)}>8</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(9)}>9</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleRatingChange(10)}>10</Dropdown.Item>
                            </DropdownButton></Col>
                        </Row>
                    </MDBCol>
                </MDBRow>
            </MDBCard>
        </>
    );
}
export default Film;
function dropdawnitemprops(filmId: number, dropdawnitemprops: any) {
    throw new Error("Function not implemented.");
}

