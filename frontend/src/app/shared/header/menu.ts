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
                label: 'Mis recursos',
                link: '/miscursos',
                parentId: 11
            },
            {
                id: 4,
                label: 'Mis colecciones',
                link: '/misrutas',
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
            {
                id: 7,
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
