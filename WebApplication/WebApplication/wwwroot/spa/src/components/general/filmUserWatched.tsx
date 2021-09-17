import { MDBCard, MDBRow, MDBCol, MDBCardImage, MDBCardBody, MDBCardTitle, MDBCardText } from "mdb-react-ui-kit";
import { DropdownButton, Dropdown, Button, Col, Row } from "react-bootstrap";
import FilmDTO from "../../types/films";

interface Props extends FilmDTO {

}

const Film = ({ nameRu, kinopoiskRating, posterUrlPreview, webUrl, description }: Props) => {
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
                    </MDBCol>
                </MDBRow>
            </MDBCard>
        </>
    );
}

export default Film;