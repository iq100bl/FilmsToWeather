import { Button, Container, Navbar } from "react-bootstrap";
import { Link, Outlet } from "react-router-dom";


const FastButton = () => {
  return (
    <>
      <div className="d-grid gap-2">
        <Link className="btn btn=primary" to={'topfilms'} >
          Получить лучшие фильмы
        </Link>{' '}
        <Button variant="secondary" size="lg">
          Large button
        </Button>
      </div>
    </>

  );
}

export default FastButton;
