import 'bootstrap/dist/css/bootstrap.min.css'
import { useRoutes } from 'react-router-dom';
import './App.css';
import FastButton from './components/entities/fastAccesButton';
import Footer from './components/entities/footer';
import Header from './components/entities/header';
import { routes } from './routes';


const App = () => {
  const appRoutes = useRoutes(routes);
  return (
    <>
      <header>
        <Header />
      </header>
      <div>
        <main role="main" className="pb=3">
          {appRoutes}
        </main>
      </div>
      <footer>
        <Footer />
      </footer>
    </>

  );
}

export default App;
