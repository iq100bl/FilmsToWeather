import { Button, Container, Navbar } from "react-bootstrap";
import { Link, Outlet } from "react-router-dom";


const FastButton = () => {
  return (
    <>
      <div className="d-grid gap-2">
        <Button className="primary" href={'spa/topfilms'} >
          Получить лучшие фильмы
        </Button>{' '}
        <Button variant="secondary" size="lg">
          Large button
        </Button>
      </div>
    </>

  );
}

export default FastButton;
