import MainPage from "./components/general/mainPage";
import Layout from "./components/Other/layout";
import Profile from "./components/Other/Profile";
import RecomendedFilm from "./components/Other/RecomendedFilm";
import TopFilms from "./components/Other/TopFilms";


export const routes = [
    {
        path: '/spa/topfilms',
        element: <Layout />,
        children: [
            { path: '/', element: <TopFilms /> },
        ]
    },
    {
        path: '/spa',
        element: <MainPage />,
    },
    {
        path: '/spa/recomendedfilm',
        element: <Layout />,
        children: [
            { path: '/', element: <RecomendedFilm /> }
        ]
    }, {
        path: '/spa/profile',
        element: <Profile />
    }

];