import { Button, Card, Col, Row } from "react-bootstrap";
import { URL } from "url";
import FilmDTO from "../../types/films";

interface Props extends FilmDTO {

}

const Film = ({ nameRu, kinopoiskRating, posterUrlPreview, webUrl, description }: Props) => {
    return (
        <>
            <Row lg={2} md={2} sm={2} xl={2} xs={2} xxl={2} className="g-4">
                <Col>
                    <Card style={{ width: '30rem' }}>
                        <Card.Img variant="top" src={posterUrlPreview} />
                        <Card.Header as="h2">Рейтинг на кинопоиске : {kinopoiskRating}</Card.Header>
                    </Card>
                </Col>
                <Col md={{ span: 2, offset: 2 }}>
                    <Card style={{ width: '30rem' }}>
                        <Card.Body>
                            <Card.Title as="h1">{nameRu}</Card.Title>
                            <Card.Text>
                                {description}
                                Больше информации : {webUrl}
                            </Card.Text>
                            <Button variant="primary">Выбрать</Button>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </>
    );
}

export default Film;