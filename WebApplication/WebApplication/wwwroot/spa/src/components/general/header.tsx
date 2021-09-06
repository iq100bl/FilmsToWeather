import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, Container, Navbar } from 'react-bootstrap';


const Header = () => {
  return (
    <>
      <Navbar bg="dark">
        <Container>
          <Navbar.Brand href="#home">
            <img
              src="3ZQC.gif"
              width="30"
              height="30"
              className="d-inline-block align-top"
              alt="React Bootstrap logo"
            />
          </Navbar.Brand>
        </Container>
      </Navbar>
      <br />
      <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="#home">
            <img
              alt=""
              src="/3ZQC.gif"
              width="30"
              height="30"
              className="d-inline-block align-top"
            />{' '}
            Film To Weather
          </Navbar.Brand>
        </Container>
      </Navbar>
    </>

  );
}

export default Header;
