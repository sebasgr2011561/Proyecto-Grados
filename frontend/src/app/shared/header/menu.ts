import { MenuItem } from './menu.model';

export const MENU1: MenuItem[] = [
    {
        id: 1,
        label: 'Cuenta',
        subItems: [
            {
                id: 2,
                label: 'Profile Settings',
                link: '/setting',
                parentId: 11
            },
            {
                id: 3,
                label: 'My Items',
                link: '/myitem',
                parentId: 11
            },
            {
                id: 4,
                label: 'My Collections',
                link: '/mycollection',
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
                label: 'Notifications',
                link: '/notification',
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
