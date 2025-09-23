import React from "react";
import LocationOnIcon from "@mui/icons-material/LocationOn";
import AccessTimeIcon from "@mui/icons-material/AccessTime";
import PhoneInTalkIcon from "@mui/icons-material/PhoneInTalk";
import "../css/Footer.css";

const Footer: React.FC = () => {
  return (
    <>
      <footer className="footer">
        <div className="footer-grid">
          {/* LEFT — logo */}
          <div className="f-col f-logo">
            <h2 className="f-logo-text">InnoClinic</h2>
          </div>

          {/* CENTER — contacts */}
          <div className="f-col f-contacts">
            <h3 className="f-heading">Contacts</h3>

            <div className="f-item">
              <LocationOnIcon className="f-icn" />
              <div className="f-lines">
                <strong>InnoClinic</strong>
                <span>Plac Zamkowy 4, 00-277 Warsaw, Poland</span>
              </div>
            </div>

            <div className="f-item">
              <AccessTimeIcon className="f-icn" />
              <div className="f-lines">
                <strong>Working hours</strong>
                <span>Monday–Sunday we operate 24/7</span>
              </div>
            </div>

            {/* phone + email объединены */}
            <div className="f-item">
              <PhoneInTalkIcon className="f-icn" />
              <div className="f-lines">
                <span>+48 123 456 789</span>
                <span>info@innoclinic.com</span>
              </div>
            </div>
          </div>

          {/* RIGHT — map */}
          <div className="f-col f-map">
            <h3 className="f-heading map-heading">You can find us here</h3>
            <div className="f-map-frame">
              <iframe
                title="InnoClinic — Royal Castle, Warsaw"
                src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2443.142932506316!2d21.01105987725104!3d52.24762327198219!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x471ecc684bfc0f7b%3A0x1a6d75b1c1d26b6c!2sRoyal%20Castle!5e0!3m2!1sen!2spl!4v1726920000000!5m2!1sen!2spl"
                loading="lazy"
                referrerPolicy="no-referrer-when-downgrade"
              ></iframe>
            </div>
          </div>
        </div>
      </footer>

      {/* bottom mini-footer */}
      {/* ===== Bottom mini-footer ===== */}
<div className="footer-bottom">
  <div className="footer-bottom-inner">
    <div className="fb-left">
      © 2025 InnoClinic. All rights reserved.
    </div>

    <div className="fb-center">
      <span className="muted">Privacy Policy</span>
      <span className="sep">|</span>
      <span className="muted">Terms of Service</span>
      <span className="sep">|</span>
      <span className="muted">FAQ</span>
    </div>

    <div className="fb-right">
      Arina Liubas Production
    </div>
  </div>
</div>

    </>
  );
};

export default Footer;
