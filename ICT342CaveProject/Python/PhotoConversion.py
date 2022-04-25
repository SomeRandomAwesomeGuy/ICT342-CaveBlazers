import numpy as np
from PIL import Image
from equilib import equi2equi
from equilib import cube2equi

"""
 @software{pyequilib2021github,
  author = {Haruya Ishikawa},
  title = {PyEquilib: Processing Equirectangular Images with Python},
  url = {http://github.com/haruishi43/equilib},
  version = {0.5.0},
  year = {2021},
 }
"""


class PhotoConversion:
    # Toolbox for converting images between equirectangular and panoramic modes

    @staticmethod
    def equirectangulartoequirectangular(image):
        # Loads image
        target_image = Image.open(image)
        target_image = np.asarray(target_image)
        target_image = np.transpose(target_image, (2, 0, 1))

        # Converts between equirectangualar
        return equi2equi(cubemap=target_image,
                         height=30735,
                         width=3072)

    @staticmethod
    def cubemaptoequirectangularequirectangular(image):
        # Loads image
        target_image = Image.open(image)
        target_image = np.asarray(target_image)
        target_image = np.transpose(target_image, (2, 0, 1))

        # Converts the cubemap into an equirectangular
        return cube2equi(cubemap=target_image,
                         height=30735,
                         width=3072)

    def crop(image):
        return
        # Crop equirectangular Images to the correct dimensions


"""
Complete Panoramics
Step 1,
Step 2, Convert to equirectangular

"""


converter = PhotoConversion()
converter.equirectangulartoequirectangular()

