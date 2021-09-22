import { Button, Container, Navbar } from "react-bootstrap";


const FastButton = () => {
  return (
    <>
      <div className="d-grid gap-2">
        <Button className="primary" href={'spa/films/topfilms'} >
          Получить лучшие фильмы
        </Button>{' '}
        <Button className="primary" href={'spa/films/recomendedfilms'}>
          Фильм по погоде
        </Button>
      </div>
    </>

  );
}

export default FastButton;
