module.exports = {
  purge: ['./src/**/*.{js,jsx,ts,tsx}', './public/index.html'],
  darkMode: false, // or 'media' or 'class'
  theme: {
    colors: {
      blue: {
        DEFAULT: '#0041f5',
        medium: '#003c70',
        dark: '#002e56',
        darkest: '#002647'
      },
      grey: {
        DEFAULT: '#dddddd'
      },
      orange: {
        DEFAULT: '#fe7f14'
      },
      white: {
        DEFAULT: '#ffffff'
      }
    },
    extend: {},
    spacing: {
      'sm': '.4rem',
      'md': '.8rem',
      'lg': '1.6rem',
      'xl': '3.2rem',
      '2xl': '4.8rem'
    }
  },
  variants: {
    extend: {},
  },
  plugins: [],
}


/*
Light grey/blue: #bfccd6;
Grey/blue: #567b9e;
*/
