import { Accordion } from "react-bootstrap";
import ProfileActiveFilms from "./profileActiveFilms";
import ProfileWathedFilms from "./profileWatchedFilms";

const Profile = () => {

    return (
        <>
            <Accordion defaultActiveKey="active">
                <Accordion.Item eventKey="active">
                    <Accordion.Header>Активные к просмотру фильмы</Accordion.Header>
                    <Accordion.Body>
                        <ProfileActiveFilms />
                    </Accordion.Body>
                </Accordion.Item>
                <Accordion.Item eventKey="watched">
                    <Accordion.Header>Просмотренные фильмы</Accordion.Header>
                    <Accordion.Body>
                        <ProfileWathedFilms />
                    </Accordion.Body>
                </Accordion.Item>
            </Accordion>
        </>
    );
}

export default Profile;