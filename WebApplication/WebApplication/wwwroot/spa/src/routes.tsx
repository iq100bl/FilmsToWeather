import MainPage from "./components/general/mainPage";
import Layout from "./components/Other/layout";
import Profile from "./components/Other/profile";

import RecomendedFilm from "./components/Other/recomendedFilms";
import TopFilms from "./components/Other/topFilms";



export const routes = [
    {
        path: '/spa/films/topfilms',
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
        path: '/spa/films/recomendedfilm',
        element: <Layout />,
        children: [
            { path: '/', element: <RecomendedFilm /> }
        ]
    }, {
        path: '/spa/profile',
        element: <Profile />
    }

];