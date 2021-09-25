import { MDBCard, MDBRow, MDBCol, MDBCardImage, MDBCardBody, MDBCardTitle, MDBCardText } from "mdb-react-ui-kit";
import { useState } from "react";
import { DropdownButton, Dropdown, Button, Col, Row } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { giveRatingFilmFromUser } from "../../services/filmService";
import FilmDTO from "../../types/films";

interface Props extends FilmDTO {

}

const ActiveFilm = ({ nameRu, kinopoiskRating, posterUrlPreview, webUrl, description, filmIdApi, nameEn, year }: Props) => {
    const [error, setError] = useState("");

    const film = ({ nameRu, kinopoiskRating, posterUrlPreview, webUrl, description, filmIdApi, year, nameEn });

    const navigate = useNavigate();

    const handleRatingChange = (rating: number) => {
        giveRatingFilmFromUser(filmIdApi, nameRu, nameEn, year, kinopoiskRating, posterUrlPreview, webUrl, description, rating).then(() => {
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
                            </MDBCardText>
                            <Row>
                                <Col><Button variant="primary">Удалить из списка</Button></Col>
                                <Col><DropdownButton id="dropdown-basic-button" title="Посмотели? Оставьте вашу оценку">
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
                        </MDBCardBody>
                    </MDBCol>
                </MDBRow>
            </MDBCard>
        </>
    );
}

export default ActiveFilm;