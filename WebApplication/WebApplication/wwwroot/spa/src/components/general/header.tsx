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
      <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
        <div className="container">
          <a className="navbar-brand" href="/spa">Film To Weather</a>
          <button className="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
            aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
            <ul className="navbar-nav flex-grow-1">
              <li className="nav-item">
                <a className="nav-link text-dark" href="/spa" >Домашняя страница</a>
              </li>
              <li className="nav-item">
                <a className="nav-link text-dark" href="/spa" >Для чего сайт нужен?</a>
              </li>
              <li className="nav-item">
                <a className="nav-link text-dark" href="/spa">Users</a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </>

  );
}

export default Header;
