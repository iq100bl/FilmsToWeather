import { MDBCard, MDBRow, MDBCol, MDBCardImage, MDBCardBody, MDBCardTitle, MDBCardText } from "mdb-react-ui-kit";
import React from "react";
import { useState } from "react";
import { Row, Col, Button, DropdownButton, Dropdown, DropdownProps } from "react-bootstrap";
import DropdownItem from "react-bootstrap/esm/DropdownItem";
import { SelectCallback } from "react-bootstrap/esm/helpers";
import { useNavigate } from "react-router-dom";
import { giveChosenFilm, giveRatingFilmFromUser } from "../../services/filmsService";
import FilmDTO from "../../types/films";


interface Props extends FilmDTO {

}

const Film = ({ nameRu, kinopoiskRating, posterUrlPreview, webUrl, description, filmId }: Props) => {
    const [error, setError] = useState("");
    const [rete, setRate] = useState("");
    const navigate = useNavigate();

    const chooseFilm = () => {
        giveChosenFilm(filmId).then(() => {
            navigate('/spa/profile');
        }).catch((e) => {
            setError(e.message);
        })
    }

    const handleRatingChange = () => {
        giveRatingFilmFromUser(filmId, setRate()).then(() => {
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
                        </MDBCardBody>
                        <Row>
                            <Col><Button variant="primary" onClick={chooseFilm}>Выбрать</Button></Col>
                            <Col><DropdownButton onClick={handleRatingChange} id="dropdown-basic-button" title="Смотели? Оставьте вашу оценку">
                                <Dropdown.Item value="1">1</Dropdown.Item>
                                <Dropdown.Item value="2">2</Dropdown.Item>
                                <Dropdown.Item value="3">3</Dropdown.Item>
                                <Dropdown.Item value="4">4</Dropdown.Item>
                                <Dropdown.Item value="5">5</Dropdown.Item>
                                <Dropdown.Item value="6">6</Dropdown.Item>
                                <Dropdown.Item value="7">7</Dropdown.Item>
                                <Dropdown.Item value="8">8</Dropdown.Item>
                                <Dropdown.Item value="9">9</Dropdown.Item>
                                <Dropdown.Item value="10">10</Dropdown.Item>
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

