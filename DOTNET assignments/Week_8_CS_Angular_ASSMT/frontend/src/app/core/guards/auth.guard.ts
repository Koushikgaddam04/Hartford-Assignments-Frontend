import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const token = localStorage.getItem('token');
  const role = localStorage.getItem('role');

  if (token) {
    // Check role requirement
    const expectedRoles = route.data['roles'] as Array<string>;
    if (expectedRoles && !expectedRoles.includes(role || '')) {
      router.navigate(['/']); // Redirect to home if unauthorized
      return false;
    }
    return true;
  }

  // Not logged in
  router.navigate(['/login']);
  return false;
};
