import { Children } from "react"
import Layout from "./components/topFilms/layout"
import MainPage from "./components/general/mainPage";
import TopFilms from "./components/topFilms/TopFilms"

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
    }

];