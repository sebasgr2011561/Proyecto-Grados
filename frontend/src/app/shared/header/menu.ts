import { AddproductComponent } from './../../pages/account/addproduct/addproduct.component';
import { MenuItem } from './menu.model';

export const MENU1: MenuItem[] = [
    {
        id: 1,
        label: 'Cuenta',
        subItems: [
            {
                id: 2,
                label: 'Configuración',
                link: '/editar',
                parentId: 11
            },
            {
                id: 3,
                label: 'Usuarios',
                link: '/usuarios',
                parentId: 11
            },
            {
                id: 4,
                label: 'Crear Recurso',
                link: '/addproduct',
                parentId: 11
            },
            {
                id: 5,
                label: 'Notificaciones',
                link: '/notification',
                parentId: 11
            },
            {
                id: 6,
                label: 'Cerrar sesión',
                link: '/',
                parentId: 11
            }
        ]
    },
    // {
    //     id: 17,
    //     label: 'Back to main demo',
    //     link: '/',
    //     isTitle: true
    // }
]
