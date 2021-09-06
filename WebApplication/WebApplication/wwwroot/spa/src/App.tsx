import 'bootstrap/dist/css/bootstrap.min.css'
import { useRoutes } from 'react-router-dom';
import './App.css';
import FastButton from './components/general/fastAccesButton';
import Header from './components/general/header';
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
    </>

  );
}

export default App;
