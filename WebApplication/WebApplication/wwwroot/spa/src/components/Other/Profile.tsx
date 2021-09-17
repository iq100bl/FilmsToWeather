import { Accordion, Col, Container, Row } from "react-bootstrap";
import FastButton from "../general/fastAccesButton"

const Profile = () => {
    return (
        <>
            <FastButton />
            <Container>
                <Accordion defaultActiveKey="0" flush>
                    <Accordion.Item eventKey="0">
                        <Accordion.Header>Accordion Item #1</Accordion.Header>
                        <Accordion.Body>

                        </Accordion.Body>
                    </Accordion.Item>
                    <Accordion.Item eventKey="1">
                        <Accordion.Header>Accordion Item #2</Accordion.Header>
                        <Accordion.Body>

                        </Accordion.Body>
                    </Accordion.Item>
                </Accordion>
            </Container>
        </>

    );
}

export default Profile;