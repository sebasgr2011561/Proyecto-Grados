import { MenuItem } from './menu.model';

export const MENU1: MenuItem[] = [
    {
        id: 1,
        label: 'Cuenta',
        subItems: [
            {
                id: 2,
                label: 'Configuraciones',
                link: '/setting',
                parentId: 11
            },
            {
                id: 3,
                label: 'Mis recursos',
                link: '/myitem',
                parentId: 11
            },
            {
                id: 4,
                label: 'Mis colecciones',
                link: '/mycollection',
                parentId: 11
            },
            {
                id: 5,
                label: 'Favoritos',
                link: '/favorite',
                parentId: 11
            },
            {
                id: 6,
                label: 'Notificaciones',
                link: '/notification',
                parentId: 11
            },
        ]
    },
    // {
    //     id: 17,
    //     label: 'Back to main demo',
    //     link: '/',
    //     isTitle: true
    // }
]
