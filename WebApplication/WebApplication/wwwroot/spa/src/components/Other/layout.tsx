import { Outlet } from "react-router-dom";


const Layout = () => {
    return (
        <>
            <text>
                Топ 250 фильмов
            </text>
            <Outlet />
        </>

    );
}

export default Layout;