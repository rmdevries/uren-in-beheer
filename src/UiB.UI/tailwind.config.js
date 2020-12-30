module.exports = {
  purge: ['./src/**/*.{js,jsx,ts,tsx}', './public/index.html'],
  darkMode: false, // or 'media' or 'class'
  theme: {
    colors: {
      blue: {
        light: '#3367f7',
        DEFAULT: '#0041f5',
        dark: '#002dab',
      },
      grey: {
        white: '#ffffff',
        light: '#f3f3f3',
        DEFAULT: '#dddddd',
        dark: '#999999',
        black: '#111111'
      },
      orange: {
        DEFAULT: '#fe7f14'
      },
    },
    extend: {},
    screens: {
      'sm': {'max': '767px'},
      'md': '768px',
      'lg': '1024px',
      'xl': '1280px',
      '2xl': '1536px',
    },
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
