import { Component, OnInit, ViewChild } from '@angular/core';
import { categoryData, resturants, Reviews } from './data';

import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  category: any;
  restaurants: any;
  review: any;
  courses: any;

  constructor(public router: Router, private api: ApiService) { }

  ngOnInit(): void {
    this.category = categoryData
    // this.restaurants = resturants
    // this.review = Reviews

    this.api.getFullData('Course').subscribe((data) => {
      if (data.isSuccess) {
        this.courses = data.data;
      } else {
        Swal.fire({
          title: 'Error!',
          text: data.message,
          icon: 'error',
          confirmButtonText: 'Cerrar'
        })
      }
    })

    document.querySelector('.cart')?.classList.add('d-none')
  }

  /**
 * Swiper setting
 */
  config = {
    slidesToShow: 4,
    initialSlide: 0,
    dots: true,
    responsive: [
      {
        breakpoint: 575,
        settings: {
          slidesToShow: 2,
        }
      },
      {
        breakpoint: 850,
        settings: {
          slidesToShow: 3,
        }
      },
      {
        breakpoint: 1080,
        settings: {
          slidesToShow: 4,
        }
      }
    ]
  };

}
