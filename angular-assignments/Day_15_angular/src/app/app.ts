import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from "../components/header/header";
import { Description } from "../components/description/description";
import { WelcomeBanner } from "../components/welcome-banner/welcome-banner";
import { InsuranceProfiles } from "../components/insurance-profiles/insurance-profiles";
import { Hdr } from "../components/hdr/hdr";
import { Footer } from "../components/footer/footer";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, Description, WelcomeBanner, InsuranceProfiles, Hdr, Footer],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Day_15_angular');
}
