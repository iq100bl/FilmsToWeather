import { Outlet } from "react-router-dom";


const Layout = () => {
    return (
        <>
            <div className="text-center">
                Выбирайте
            </div>
            <Outlet />
        </>

    );
}

export default Layout;