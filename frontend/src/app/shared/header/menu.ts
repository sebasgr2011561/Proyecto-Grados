import { AddproductComponent } from './../../pages/account/addproduct/addproduct.component';
import { MenuItem } from './menu.model';

export const MENU1: MenuItem[] = [
    {
        id: 1,
        label: 'Cuenta',
        subItems: [
            {
                id: 2,
                label: 'Configuracion de perfil',
                link: '/setting',
                parentId: 11
            },
            {
                id: 3,
                label: 'Creacion de usuarios',
                link: '/crearUsuario',
                parentId: 11
            },
            {
                id: 4,
                label: 'Vizualizacion de usuarios  ',
                link: '/usuarios',
                parentId: 11
            },
            {
                id: 5,
                label: 'Favorites',
                link: '/favorite',
                parentId: 11
            },
            {
                id: 6,
                label: 'Cracion de recursos',
                link: '/addproduct',
                parentId: 11
            },
        ]
    },
    {
        id: 17,
        label: 'Back to main demo',
        link: '/',
        isTitle: true
    }
]
