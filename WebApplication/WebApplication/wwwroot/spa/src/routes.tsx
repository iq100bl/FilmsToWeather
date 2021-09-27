import MainPage from "./components/other/mainPage";
import Layout from "./components/other/layout";
import Profile from "./components/entities/profile";

import RecomendedFilm from "./components/other/recomendedFilms";
import TopFilms from "./components/other/topFilms";



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
        path: '/spa/films/recomendedfilms',
        element: <Layout />,
        children: [
            { path: '/', element: <RecomendedFilm /> }
        ]
    }, {
        path: '/spa/profile',
        element: <Profile />
    }

];