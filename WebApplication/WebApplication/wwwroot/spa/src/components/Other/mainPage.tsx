import { Container, Row, Col } from "react-bootstrap";
import FastButton from "../entities/fastAccesButton"
import Profile from "../entities/profile";

const MainPage = () => {
    return (
        <>
            <Container>
                <Row>
                    <Col>
                        <FastButton />
                    </Col>
                    <Col xs={6}>
                        <Profile />
                    </Col>
                </Row>
            </Container>
        </>

    );
}

export default MainPage;