import { AddproductComponent } from './../../pages/account/addproduct/addproduct.component';
import { MenuItem } from './menu.model';

// Menu Administrador
export const MENU_ADMIN: MenuItem[] = [
    {
        id: 1,
        label: 'Cuenta',
        subItems: [
            {
                id: 1,
                label: 'Mi perfil',
                link: '/editar',
                parentId: 11
            },
            {
                id: 2,
                label: 'Roles',
                link: '/roles',
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
                label: 'Categorias',
                link: '/categories',
                parentId: 11
            },
            {
                id: 5,
                label: 'Rutas',
                link: '/routes',
                parentId: 11
            },
            {
                id: 6,
                label: 'Recursos',
                link: '/courses',
                parentId: 11
            }
        ]
    }
]

// Menu Docente
export const MENU_DOC: MenuItem[] = [
    {
        id: 1,
        label: 'Cuenta',
        subItems: [
            {
                id: 1,
                label: 'Mi perfil',
                link: '/editar',
                parentId: 11
            },
            {
                id: 2,
                label: 'Categorias',
                link: '',
                parentId: 11
            },
            {
                id: 3,
                label: 'Rutas',
                link: '',
                parentId: 11
            },
            {
                id: 4,
                label: 'Recursos',
                link: '',
                parentId: 11
            }
        ]
    }
]

// Menu Estudiante
export const MENU_EST: MenuItem[] = [
    {
        id: 1,
        label: 'Cuenta',
        subItems: [
            {
                id: 1,
                label: 'Mi perfil',
                link: '/editar',
                parentId: 11
            },
            {
                id: 2,
                label: 'Mis aprendizajes',
                link: '',
                parentId: 11
            },
            {
                id: 3,
                label: 'Mis rutas de aprendizaje',
                link: '',
                parentId: 11
            }
        ]
    }
]
