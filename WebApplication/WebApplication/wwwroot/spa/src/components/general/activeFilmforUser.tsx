import { MDBCard, MDBRow, MDBCol, MDBCardImage, MDBCardBody, MDBCardTitle, MDBCardText } from "mdb-react-ui-kit";
import { DropdownButton, Dropdown, Button, Col, Row } from "react-bootstrap";
import FilmDTO from "../../types/films";

interface Props extends FilmDTO {

}

const ActiveFilm = ({ nameRu, kinopoiskRating, posterUrlPreview, webUrl, description }: Props) => {
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
                                    <Dropdown.Item href="#/action-1">1</Dropdown.Item>
                                    <Dropdown.Item href="#/action-2">2</Dropdown.Item>
                                    <Dropdown.Item href="#/action-3">3</Dropdown.Item>
                                    <Dropdown.Item href="#/action-4">4</Dropdown.Item>
                                    <Dropdown.Item href="#/action-5">5</Dropdown.Item>
                                    <Dropdown.Item href="#/action-6">6</Dropdown.Item>
                                    <Dropdown.Item href="#/action-7">7</Dropdown.Item>
                                    <Dropdown.Item href="#/action-8">8</Dropdown.Item>
                                    <Dropdown.Item href="#/action-9">9</Dropdown.Item>
                                    <Dropdown.Item href="#/action-10">10</Dropdown.Item>
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